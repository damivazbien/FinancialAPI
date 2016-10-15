Welconme!

I used the template yoman scanffolding for API and Test.

Test (Method)
 -WhenSaveDataAndOkThen200: Try save data if is OK return 200.
 -WhenSaveNewDataOkAcceptable: I use a json, and for create a new item copy the data from last item, if is OK return Aceptable.
 -WhenDataNotFound404: If json don't have the data pass, return 404.

Src
  Controller -> consume a services for work with search json.
  Services -> connect azure (blobstorage) and get json data. (Not yet).
  appsettings.json -> all the configuration for connect with azure. (Not yet).

Simple and clear!!

Enjoy!

resources:

https://www.npmjs.com/package/generator-aspnet
https://xunit.github.io/
  

