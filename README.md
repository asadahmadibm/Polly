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
    Policy.Excute(currency.Insert)
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


منبع [App-vNext/Polly ](https://github.com/App-vNext/Polly)https://github.com/App-vNext/Polly
