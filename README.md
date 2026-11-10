# مینی‌سیستم فروشگاه و انبارداری (MyShop) 🛒

یک پروژه جامع، ماژولار و سازمانی به زبان **`#C`** و فریم‌ورک **`NET.`** که با بهره‌گیری از **معماری سه‌لایه (3-Tier Layered Architecture)**، اصول **شیءگرایی (`OOP`)** و ابزار **`EF Core (Code-First)`** متصل به پایگاه داده **`SQL Server`** پیاده‌سازی شده است.

این پروژه به عنوان یک زیرساخت استاندارد و عمیق، پیش از ورود به دنیای توسعه وب با **`ASP.NET Core`** طراحی و کدنویسی شده است.

---

## 🏛️ معماری سه‌لایه پروژه (3-Tier Architecture)

کل سولوشن برای جداسازی وظایف (`Separation of Concerns`) به ۴ پروژه مستقل تقسیم شده است:

```text
MyShop/
│
├── 📁 MyShop.Entities      (Class Library)  --> مدل‌های دامین، کلاس پایه و Enumها
├── 📁 MyShop.DAL           (Class Library)  --> لایه دسترسی به داده (DbContext، مایگریشن‌ها و ریپازیتوری‌ها)
├── 📁 MyShop.BLL           (Class Library)  --> لایه منطق بیزینس (اعتبارسنجی‌ها، سرویس‌ها و منطق انبارداری)
└── 📁 MyShop.UI            (Console App)    --> لایه نمایش (کنسول تعاملی و منوها)
```

### 🔒 قانون طلایی وابستگی‌ها:
- لایه **`UI`** فقط به **`BLL`** و **`Entities`** دسترسی دارد (**`UI` هرگز مستقیم با `DAL` صحبت نمی‌کند!**).
- لایه **`BLL`** به **`DAL`** و **`Entities`** متصل است.
- لایه **`DAL`** به **`Entities`** متصل است.
- لایه **`Entities`** کاملاً مستقل بوده و به هیچ پروژه‌ای وابسته نیست.

---

## 🧠 مفاهیم کلیدی شیءگرایی و مهندسی نرم‌افزار پیاده‌شده

1. **وراثت و تجرید (`Inheritance & Abstraction`):**
   - طراحی کلاس انتزاعی `BaseEntity` برای نگهداری شناسه یکتا (`Id`) و رعایت اصل `DRY (Don't Repeat Yourself)`.
2. **الگوی مخزن و اینترفیس‌ها (`Repository Pattern & Interfaces`):**
   - پیاده‌سازی اینترفیس‌های `IProductRepository`، `ICustomerRepository` و `IOrderRepository` برای جداسازی کامل بیزینس از کدهای دیتابیس.
3. **اعتبارسنجی با الگوی نگهبان (`Guard Clauses`):**
   - کنترل دقیق صحت داده‌ها (عدم خالی بودن نام، قیمت بزرگتر از صفر، موجودی انبار غیرمنفی) با بازگشت زودهنگام (`Early Return`).
4. **بارگذاری مشتاقانه (`Eager Loading`) با دستور `Include`:**
   - لود کردن هم‌زمان اقلام فاکتور (`OrderItems`) همراه با سربرگ فاکتور (`Orders`) با متد `.Include(o => o.Items)` در `EF Core`.
5. **ثبت سابقه تاریخی قیمت (`Price Snapshotting`):**
   - ذخیره قیمت کالا در لحظه خرید داخل جدول `OrderItem` برای مصون ماندن فاکتورهای گذشته از نوسانات بعدی قیمت کالاها.
6. **کسر خودکار موجودی انبار:**
   - با ثبت هر سفارش، موجودی انبار محصول در `SQL Server` اعتبارسنجی شده و به اندازه تعداد خرید کسر می‌گردد.

---

## 🗄️ جداول پایگاه داده در `SQL Server`

دیتابیس به صورت کاملاً خودکار با رویکرد **`Code-First Migrations`** در `SQL Server` ساخته شده است:

- **جدول `Products`**: شناسه، نام، قیمت (`decimal`)، موجودی انبار، توضیحات
- **جدول `Customers`**: شناسه، نام، نام خانوادگی، نام کاربری، شماره تماس، آدرس، تاریخ ثبت‌نام
- **جدول `Orders`**: شناسه، شناسه مشتری (`Foreign Key`)، تاریخ سفارش، وضعیت با `Enum`، مبلغ کل
- **جدول `OrderItems`**: شناسه، شناسه سفارش (`Foreign Key`)، شناسه کالا (`Foreign Key`)، تعداد، قیمت لحظه خرید

---

## 🚀 راهنمای راه‌اندازی و اجرا

### پیش‌نیازها:
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022 / 2026](https://visualstudio.microsoft.com/)
- [Microsoft SQL Server & SSMS](https://www.microsoft.com/sql-server)

### مراحل اجرا:
۱. **کلون کردن ریپازیتوری:**
```bash
git clone https://github.com/skinoxer/MyShop-3Tier-Architecture.git
```

۲. **بررسی کانکشن استرینگ:**  
در فایل `MyShop.DAL/AppDbContext.cs` از صحت اتصال به `SQL Server` محلی خود اطمینان حاصل کنید:
```csharp
optionsBuilder.UseSqlServer("Server=.;Database=MyShopDb;Trusted_Connection=True;TrustServerCertificate=True;");
```

۳. **اعمال مایگریشن‌ها در دیتابیس:**  
کنسول **Package Manager Console** را در ویژوال استودیو باز کنید (مطمئن شوید `Default project` روی `MyShop.DAL` است) و دستور زیر را اجرا کنید:
```powershell
Update-Database
```

۴. **اجرای برنامه:**  
پروژه `MyShop.UI` را به عنوان `Startup Project` انتخاب کرده و با کلیدهای **`Ctrl + F5`** برنامه را اجرا کنید.

---

## 👨‍💻 سازنده
- **گیت‌هاب:** [@skinoxer](https://github.com/skinoxer)
