# ogrenciNotSistemi

C# ile geliştirilen öğrenci not sistemi uygulaması. (Console App)
Bu proje, C# programlama dili ile yazılmış basit bir konsol tabanlı öğrenci not takip sistemidir. Öğrenci bilgileri txt dosyasına kaydedilir ve uygulama her başlatıldığında bu dosyadan veriler okunur.

# Özellikler

- Tüm öğrencileri listeleyebilme  
- Yeni öğrenci ekleyebilme  
- Öğrenci silebilme  
- Soyad bilgisine göre öğrenci arama  
- Not ortalaması 50’nin altında olan öğrencileri listeleme  
- Verileri `.txt` dosyasına kaydetme ve dosyadan yükleme  
- En fazla 15 öğrenci kayıt edilebilir (dizi sınırı)

# Dosya Yapısı

Tüm öğrenci verileri şu dizindeki `ogrenciBilgileri.txt` dosyasına kaydedilir:

```
C:\Users\kullaniciAdiniz\Desktop\ogrenciNotSistemi\ogrenciBilgileri.txt
```

> Uygulama ilk çalıştırıldığında bu dosya mevcut değilse otomatik olarak oluşturulur.

# Kullanım

1. Uygulama çalıştırıldığında kullanıcıya bir ana menü sunulur.
2. Menüden seçim yapılarak işlem gerçekleştirilir.
3. Çıkış yapıldığında bilgiler `.txt` dosyasına kaydedilir.

# Örnek Ana Menü:

```
**Hosgeldiniz..**
[1] Tum Ogrenciler:
[2] Yeni Ogrenci Ekle:
[3] Ogrenci Sil:
[4] Soyad Bilgisine Gore Ogrenci Ara:
[5] Cikis yap ve Kaydet...
[6] Ortalama Altinda Kalan Ogrenciler:
```

# Kurallar ve Kısıtlamalar

- Öğrenci numarası 4 haneli olmalı ve benzersiz olmalıdır.
- Not ortalaması ve yaş gibi bilgiler sayısal formatta girilmelidir.
- Maksimum öğrenci sayısı: 15

# Geliştirici Notu

> Bu proje, C#'ta temel dosya işlemleri, diziler ve kontrol yapıları gibi konuları pekiştirmek amacıyla hazırlanmıştır. Eğitim ve öğrenim amacıyla geliştirilmiştir.
