# InterfaceDemo


Interface leri bir sınıfa yön veren öğretmen gibi düşünebilirsiniz , öğretmenin sınıftaki işi genel olarak nedir öğrencilerine doğru yolu göstermek ne yapacaklarını söylemektir işte interface’lerde c# dilindeki class’ların hocaları gibidir.Interface’ler içinde kod yazılmaz dediğimiz gibi sadece yön verir class’a ne yapacagını söyler.Bir class birden çok interface ‘i uygulayabilir ama class bir interface ‘yi kendisine uyguluyor ise kesinlikle tüm method larını ezmek zorundadır.Interface ‘ leri tanımlarken default olarak public atanır protected veya private olarak belirtemeyiz.Interface’lerin yapıcı method’u olmaz aynı şekilde alan (fields) ‘larıda tanımlayamayız.Bu kadar bilgiden sonra birazda kod yazalım.İlk olarak 2 tane interface tanımlayalım.

```C#
 public interface IAracOzellikleri
        {
            string Marka { get; }
            string Model { get; }
            int Hız { get; set; }
            double Fiyat { get; set; }

            int Gosterge(int deger);

            // interface içinde yazacağımız method'lar içinde kod yazamayız 
            // kod kısmını bu interface 'i kenisine uygulamış (implementa) sınıf içerisinde yazmalıyız
            void Bilgiler();
        }

        public interface IAracPuan
        {
            double AracPuani(double puan);
        }
```
Interface adları kesinlikle olmasa bile genellikle I ile başlar .Net Framework içindede bir çok örnekleri vardır
örnegin : IComparer , IEnumerable sizde bu kurala uyarsanız çok daha anlaşılır kod geliştirmiş olursunuz.
Interface lerin tanımlanması interface kelimesi ile yapılmaktadır bu kelimeden sonra gelen kısım interface ‘mizin adıdır.
Bizim örnekte kullanacağımız 2 tane interface miz var 1. IAracOzellikleri burada her araçta bulunması gereken alanlar yer almaktadır 
ayrıca Gosterge adında bir de method içermektedir 2. interface ‘ imizde ise sadece AracPuani methd’umuz vardır 
bu method’un amacıda araç puanı method unu bu interface ‘den türeyen class ‘lara uygulayabilmek.
Burada dikkat edilecek en önemli noktalar dan bir taneside Marka ve Model property ‘lerinin sadece get özelliklerinin bulunması anlayacagınız üzere set değeri olmadığı için bu property’lere atama işlemi yapılamamaktadır sadece içlerindeki bulunan degerler okunabilmektedir.
Eğer sadece get özelliği olan bir property’ye değer atamaya çalışırsak şöyle bir hata alırız

Aldığımız hata Mercedes sınıfındaki Marka property ‘ sinin sadece okunabilir olmasıyla ilgili herhangi bir değer atamaya çalışınca derleme anında bu şekilde uyarıyor bizi.Interface’lerimizi yazdıktan sonra 2 tane Mercedes ve Bmw adında sınıf oluşturalım 
ve kendi interface’lerimizi uygulayalım.

 ```C#       
        public class Mercedes : IAracOzellikleri
        {
            private string marka = "Mercedes";
            private string model = "A Serisi";
            private int hiz;
            private double fiyat;

            public string Marka
            {
                // Mercedes sınıfında marka değişemeyeceği için set tanımlamadık
                // sadece model ve marka sını okuyabiliyoruz
                get { return marka; }
            }

            public string Model
            {
                get { return model; }
            }

            public int Hız
            {
                // Mercedes sınıfımızın hız özelliğini atayabiliriz
                get { return hiz; }
                set { hiz = value; }
            }

            public double Fiyat
            {
                get { return fiyat; }
                set { fiyat = value; }
            }

            public int Gosterge(int deger)
            {
                return (deger);
            }

            public void Bilgiler()
            {
                Console.WriteLine("Marka : " + Marka);
                Console.WriteLine("Model : " + Model);
                Console.WriteLine("Fiyat : " + Fiyat);
                Console.WriteLine("Hız : " + Hız);
                Console.WriteLine("Gösterge : " + Gosterge(340));
            }
        }
```

Buradaki Mercedes sınıfımızda sadece IAracOzellikleri interface’imizi uyguladık 
ve interface içindeki tüm property’lerin get ve set atamalarını yaptık Gosterge 
ve Bilgiler method’larınıda interface’imizde tanımladığımız için kullandık Bilgiler method ‘ umuzda
sınıfımızın özelliklerinn ekrana yazdırıyoruz bu sefer console uygulaması olduğu için genel bir arayüz yapmıyoruz.
Marka ve Model property ‘lerimize dikkat ederseniz sadece get kullandık bunun nedeni interfacemizde’de sadece get kullanmıştık.
Buradan çıkaracağımız interface de nasıl kullanılmasını istiyorsanız belirliyorsunuz 
ve tanımladığınız class sizin tanımladığınız sınırlar doğrultusunda gitmek zorunda kalıyor tabiki üstüne ekleyerek class genişleyebilir.
Şimdi Bmw sınıfımıza bakalım.

```C#
  // Bir sınıf birden çok interface i uygulayabilir
        public class Bmw : IAracOzellikleri, IAracPuan
        {
            // Bmw sınıfı oldugu için marka ve model 
            // değişkenlerimizi statik tanımladık
            private string marka = "Bmw";
            private string model = "X5";
            private int hiz;
            private double fiyat;

            public double AracPuani(double puan)
            {
                // gerekli işlmeler interface içerisinde değil 
                // tanımladığımız sınıf içerisinde yapılmalıdır
                return puan * 3.6;
            }

            public string Marka
            {
                get
                {
                    return marka;
                }
            }

            public string Model
            {
                get
                {
                    return model;
                }
            }

            public int Hız
            {
                get
                {
                    return hiz;
                }
                set
                {
                    hiz = value;
                }
            }

            public double Fiyat
            {
                get
                {
                    return fiyat;
                }
                set
                {
                    fiyat = value;
                }
            }

            public int Gosterge(int deger)
            {
                return deger;
            }

            public void Bilgiler()
            {
                Console.WriteLine("Marka : " + Marka);
                Console.WriteLine("Model : " + Model);
                Console.WriteLine("Fiyat : " + Fiyat);
                Console.WriteLine("Hız : " + Hız);
                Console.WriteLine("Gösterge : " + Gosterge(300));
                Console.WriteLine("Puan : " + AracPuani(2000));
            }
        }
```     

Bmw sınıfımızda kendi yazdığımız 2 interface ‘ ide uyguluyoruz 1 class birden çok interface’i uygulayabilir uygulama şekli 2 interface adı arasına virgul koymaktır.Bu sınıfımızdada marka ve model özelliklerimizi defaut olarak atıyoruz ve onların set özellikleri olmadığına dikkat ediniz.Bmw sınıfımız 2. bir interface ‘i uyguladı peki 1.sinden farkı ne oldu birden çok interface’i kendisine uygulamış class ‘lar uygulanan tüm interface’lerin özelliklerini veya method’larını kullanmak zorundadır.Bmw sınıfımızda AracPuanı’da hesaplanmaktadır buda IAracPuan interface’sinden gelmektedir.Şimdi class ‘larımızı hazırladığımıza göre onları çağıralım ve atanması gereken değerlerini atadıktan sonra sonuca bakalım.
        
```C#        
namespace InterfaceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Mercedes mcd = new Mercedes();
            mcd.Fiyat = 2000;
            mcd.Hız = 280;
            mcd.Bilgiler();

            Console.WriteLine("");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");

            Bmw bmw = new Bmw();
            bmw.Fiyat = 2500;
            bmw.Hız = 290;
            bmw.Bilgiler();

            Console.ReadLine();
        
        }
   ```
