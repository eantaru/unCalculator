# unCalculator

unCalculator is not a calculator, it's just conversion from numbers to human readable.

```
## How to use
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

step by step how I produce:
1. Check is string contains only numbers, if yes continue to step 2.
2. Split string into 2 by separating by dot ".", first string is dollar and second is cent 


![alt source](https://raw.githubusercontent.com/eantaru/unCalculator/master/names_of_large_numbers.png)




## License
[MIT](https://choosealicense.com/licenses/mit/)