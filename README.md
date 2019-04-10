# unCalculator

unCalculator is not a calculator, it's just conversion from numbers to human readable.

## Needed
```
In your system should have net framework (4.7.x or newest), you may download from
https://dotnet.microsoft.com/download
or directly
https://dotnet.microsoft.com/download/thank-you/net472
```

## How to use
- open cmd/powershell
- go to root project
- run: .\bin\Release\netcoreapp2.2\win10-x64\unCalculator

- instant
.\bin\Release\netcoreapp2.2\win10-x64\unCalculator

parameters may used:
test [numbers]
file [path to file, separated by new line]

ex:
   .\bin\Release\netcoreapp2.2\win10-x64\unCalculator test 1234567890
   .\bin\Release\netcoreapp2.2\win10-x64\unCalculator file "c:\test-case.txt"
```

## Brief

How I produce:
1. Check is string contains only numbers, if yes continue to step 2.
2. Split string into 2 by separating by dot ".", first string is dollar and second is cent.
3. Each strings split again by 18 characters and convert to `ulong`, why 18, I will explain later ~~as a note~~.
4. From 18 max digits `ulong` I capture 3 digits with formula:

```
ulong source = 1234567890
uint digits = source % 1000 //as hundreds


uint hundred = digits / 100
uint ten = digits % 10 / 10
uint unit = digits % 10
```
5. Map `hundred`, `ten`, and `unit` to string, each multiple by 3 will translate to number prefix as seen on table below

![table of number suffix](https://raw.githubusercontent.com/eantaru/unCalculator/master/number_suffix.png)

![table of large numbers](https://raw.githubusercontent.com/eantaru/unCalculator/master/names_of_large_numbers.png)



## 18 Characters
Why? Largest number in decimal is 9, `ulong` can take 19 times of 9 (`9999999999999999999`) but 19 cannot multiply by 3 (19÷3), in result 18 (`999999999999999999`) is my solution

## Test Case
```
PS E:\MITRAIS\WORKSPACE\DotNet\unCalculator> .\bin\Release\netcoreapp2.2\win10-x64\unCalculator
source: 300
Result:
three hundred  dollars
source: 3500
Result:
 three thousandfive hundred  dollars
source: 3004
Result:
 three thousand four  dollars

——————————————

PS E:\MITRAIS\WORKSPACE\DotNet\unCalculator> .\bin\Release\netcoreapp2.2\win10-x64\unCalculator test 1234567890.980
source: 1234567890.980
Result:
 one billiontwo hundred thirty four millionfive hundred sixty seven thousandeight hundred ninety  dollars and  ninety eight  cents

——————————————

PS E:\MITRAIS\WORKSPACE\DotNet\unCalculator> .\bin\Release\netcoreapp2.2\win10-x64\unCalculator file E:\MITRAIS\WORKSPACE\DotNet\unCalculator\test-case.txt
source: 1
Result:
 one  dollars
source: 300
Result:
three hundred  dollars
source: 5003
Result:
 five thousand three  dollars
source: 47390
Result:
 forty seven thousandthree hundred ninety  dollars
source: 29847239472471.1824718924
Result:
 twenty nine trillioneight hundred forty seven billiontwo hundred thirty nine millionfour hundred seventy two thousandfour hundred seventy one  dollars and  one billioneight hundred twenty four millionseven hundred eighteen thousandnine hundred twenty four  cents
source: 0.18748917412384712894
Result:
 dollars eighteen quintillionseven hundred forty eight quadrillionnine hundred seventeen trillionfour hundred twelve billionthree hundred eighty four millionseven hundred twelve thousandeight hundred ninety four  cents
source: 81788190000000000.00000
Result:
 eighty one quadrillionseven hundred eighty eight trillionone hundred ninety billion dollars
source: 1741897412347189471289471471984712894712894712389412984712894712894
Result:
 one unvigintillionseven hundred forty one vigintillioneight hundred ninety seven novedecillionfour hundred twelve octodecillionthree hundred forty seven septedecillionone hundred eighty nine sedecillionfour hundred seventy one quinquadecilliontwo hundred eighty nine quanttuordecillionfour hundred seventy one tredecillionfour hundred seventy one duodecillionnine hundred eighty four undecillionseven hundred twelve decillioneight hundred ninety four nonillionseven hundred twelve octillioneight hundred ninety four septillionseven hundred twelve sextillionthree hundred eighty nine quintillionfour hundred twelve quadrillionnine hundred eighty four trillionseven hundred twelve billioneight hundred ninety four millionseven hundred twelve thousandeight hundred ninety four  dollars
source: 1894123094812094812930481094812093484812748
Result:
 one tredecillioneight hundred ninety four duodecillionone hundred twenty three undecillion ninety four decillioneight hundred twelve nonillion ninety four octillioneight hundred twelve septillionnine hundred thirty sextillionfour hundred eighty one quintillion ninety four quadrillioneight hundred twelve trillion ninety three billionfour hundred eighty four millioneight hundred twelve thousandseven hundred forty eight  dollars
source: 9000000000000000000000000000000000000000000000000000000000000000000000
Result:
 nine duovigintillion dollars
3894092384242048230948d9203842309842309 is not numeric, source shall only numeric
100000000000000000000000O0000000000000000000 is not numeric, source shall only numeric
PS E:\MITRAIS\WORKSPACE\DotNet\unCalculator>
```


## License
[MIT](https://choosealicense.com/licenses/mit/)