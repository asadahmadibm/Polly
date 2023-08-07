# Polly

## کتابخانه ای برای مدیریت خطا میباشد که سیاستهای زیر را پس از رخداد خطا دنبال میکند      
    Retry : سعی مجدد 
    Circuit Breaker اگرسناریویی  خطا داشت در فراحوانیهای مجدد تا مدت زمان خاص اجرا نگردد 
    builkhead  isolation
    timeout اگر زمان اجرای سناریو از یک حد بیشتر شد  خطا بده
    Fallback در صورت شکست سناریو نتیجه جایگزین را اعلام میکند
    Rate-limit محدود کردن تعداد درخواستها
    Cache ذخیره سازی نتیجه درخواست در کش و استفاده از ان در فراخوانی مجدد
    PolicyWrap ترکیبی از استراتژیهای بالا را اعمال میکند

    
## simple Example :
    var Policy=Policy.Handle<SqlException>().Retry();
    Policy.Excute(()=>currency.Insert)
نکته اینکه باید دقیقا Exception مورد نظر را در بخش Config به کار برد  که میتوان انواع exception  را نیز تعریف کرد مانند   

    Policy
      .Handle<HttpRequestException>()
      .Or<OperationCanceledException>()
    یا
    Policy
      .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.NotFound)
    
    
    Policy
        .Handle<SomeExceptionType>()
        .Retry(3, onRetry: (exception, retryCount) =>
        {
            // Add logic to be executed before each retry, such as logging
        });


منبع 
https://github.com/App-vNext/Polly

https://www.c-sharpcorner.com/article/using-retry-pattern-in-asp-net-core-via-polly/

https://virgool.io/@mohsen_kasraeifar/%D9%BE%DB%8C%D8%A7%D8%AF%D9%87-%D8%B3%D8%A7%D8%B2%DB%8C-%D8%A7%D9%84%DA%AF%D9%88%DB%8C-circuit-breaker-%D8%A8%D8%A7-ihttpclientfactory-%D9%88-polly-qohlvnk6rvze

https://www.dntips.ir/post/2786/%D9%BE%DB%8C%D8%A7%D8%AF%D9%87-%D8%B3%D8%A7%D8%B2%DB%8C-%D9%85%DA%A9%D8%A7%D9%86%DB%8C%D8%B3%D9%85-%D8%B3%D8%B9%DB%8C-%D9%85%D8%AC%D8%AF%D8%AF-retry

https://dotnetdocs.ir/Fa/Post/55/%D9%BE%DB%8C%D8%A7%D8%AF%D9%87-%D8%B3%D8%A7%D8%B2%DB%8C-circuit-breaker-%D8%AF%D8%B1-asp.net-core

