# AnagramSolver

C# program

## Usage

WebApp:
```C#
    cd AnagramSolver.WebApp/
    dotnet watch run


    Home/Index.cshtml/{word}
    Dictionary/{page_number}


    /api/dictionary/{index}
    /api/dictionary/download
    /api/anagram/{word}
    // using Anagramica api
    /api/anagram/anagramica/{word}
```


Console Application:
```C#
    cd AnagramSolver/
    dotnet restore
    dotnet run
```

## Testing
```C#
    cd AnagramSolver.Tests/
    dotnet test
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
Please make sure to update tests as appropriate.
