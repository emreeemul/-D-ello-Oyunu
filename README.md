# -D-ello-Oyunu
Duello Oyunu
Proje Hakkında
Duello, konsol tabanlı bir dövüş oyunudur. Oyuncular, farklı silahlar seçerek stratejik hamlelerle rakiplerini alt etmeye çalışır. Oyunun temel amacı, rakibin hamlelerini tahmin ederek uygun bir karşılıkla savaşı kazanmaktır.
Özellikler
•	Normal Mod: Tek bir rakiple dövüş.
•	Sonsuzluk Modu: Kazandıkça daha güçlü rakiplerle savaşma.
•	Co-op Modu: Yerel iki oyunculu dövüş modu.
•	Silah Seçenekleri:
o	Balta: Yüksek hasar verir.
o	İkili Kılıç: Hasardan kaçınma şansı sunar.
o	Topuz ve Kalkan: Ekstra savunma sağlar.
•	Renkli Konsol Çıkışları: Oyunun çeşitli durumları renkli olarak ekrana yansıtılır.
•	Rastgele Rakip Silahı: Rakiplerin silahları rastgele seçilir.
Kullanılan Teknolojiler
•	Programlama Dili: C#
•	Framework: .NET Console Application
•	Kodlama Teknikleri:
o	Soyutlama (Abstraction)
o	Kapsülleme (Encapsulation)
o	Kalıtım (Inheritance)
o	Polimorfizm (Polymorphism)
o	Kurucu ve Yok Ediciler (Constructor ve Destructor)
________________________________________
Nasıl Çalıştırılır?
Gereksinimler
•	.NET Framework
•	Visual Studio veya benzeri bir IDE
Kurulum
1.	Bu projeyi bilgisayarınıza indirin.
2.	Visual Studio gibi bir IDE ile projeyi açın.
3.	Projeyi derleyip çalıştırın (F5 tuşuna basabilirsiniz).
4.	Oyunun başlangıç ekranında bir mod seçerek oynamaya başlayın.
________________________________________
•	Rakibin canı her turda artar.
•	Oyuncunun canı her tur başlangıcında 1000'e sıfırlanır.
Co-op Modu
•	İki oyuncu birbiriyle dövüşür.
•	1.Oyuncu: q, w, e tuşları ile hamle yapar.
•	2.Oyuncu: i, o, p tuşları ile hamle yapar.
•	Rakibinizin hamlesini tahmin edip doğru bir karşılık vererek savaşı kazanmaya çalışın.
________________________________________
Hamle Yapma
•	Hamlelerin güçlü ve zayıf olduğu durumlar:
o	q (Yukarı): Aşağı hamleye (e) karşı güçlüdür.
o	w (Orta): Yukarı hamleye (q) karşı güçlüdür.
o	e (Aşağı): Orta hamleye (w) karşı güçlüdür.
•	Rakibe saldırmak için aşağıdaki tuşları kullanabilirsiniz:
o	q: Yukarı saldırı
o	w: Orta saldırı
o	e: Aşağı saldırı
•	x tuşuna basarak oyundan çıkabilirsiniz.
•	1. Balta 🪓
•	Hasar: 150
•	Savunma: 0
•	Özellikler:
•	Baltanın temel özelliği yüksek hasar vermesidir.
•	Ekstra savunma sağlamaz, yani oyuncu tamamen saldırıya odaklanır.
•	Yüksek saldırı gücü nedeniyle hızlı bir şekilde rakibin canını azaltmak isteyen oyuncular için uygundur.
•	Avantaj:
•	Rakibin savunmasını hızlı bir şekilde aşarak güçlü saldırılar yapabilirsiniz.
•	Dezavantaj:
•	Rakibin güçlü saldırılarına karşı savunmasız kalabilirsiniz.
•	________________________________________
•	2. İkili Kılıç ⚔️
•	Hasar: 100
•	Savunma: 0
•	Özellikler:
•	İkili Kılıç, %50 ihtimalle gelen bir saldırıyı tamamen engelleyebilir.
•	Hasar verme kapasitesi Baltaya göre daha düşüktür.
•	Oynanışta stratejik bir silah olup, şans faktörü içerir.
•	Avantaj:
•	Hasardan kaçınma özelliği sayesinde rakibin saldırılarına karşı ekstra direnç sağlayabilirsiniz.
•	Dezavantaj:
•	Saldırı gücü nispeten düşük olduğu için uzun vadeli mücadelelerde rakibi yenmek zorlaşabilir.
•	________________________________________
•	3. Topuz ve Kalkan 🛡️
•	Hasar: 100
•	Savunma: 50
•	Özellikler:
•	Ekstra 50 savunma puanı sayesinde, rakibin verdiği hasar azaltılır.
•	Dengeli bir silah: Hem savunma hem saldırı özellikleri içerir.
•	Rakibin saldırılarına karşı daha dirençlidir, bu nedenle uzun süre hayatta kalmayı sağlar.
•	Avantaj:
•	Savunma odaklı oyuncular için mükemmel bir seçenektir.
•	Rakibin yüksek hasarlarını hafifletir, bu da stratejik avantaj sağlar.
•	Dezavantaj:
•	Saldırı gücü düşük olduğundan, rakibin canını azaltmak daha uzun sürebilir.
•	
Normal Mod
•	Tek bir rakiple savaşılır.
•	Oyuncu ve rakibin başlangıç canı 1000'dir.
•	Hamlelerinizi yaparak rakibin canını sıfıra indirmeye çalışın.
Sonsuzluk Modu
•	Rakipleri birer birer yenerek ilerleyin.
•	Her yeni rakibin canı bir önceki rakibin canından daha yüksektir.
•	Her turda oyuncunun canı 1000 olarak sıfırlanır.
Co-op Modu
•	İki oyuncu arasında yerel bir dövüş gerçekleşir.
o	1. Oyuncu: q, w, e tuşlarıyla hamle yapar.
o	2. Oyuncu: i, o, p tuşlarıyla hamle yapar.

