Push-Location $PSScriptRoot
try {
    dotnet restore ..\Repro.sln
    dotnet build ..\Repro.sln --no-restore --configuration release
    dotnet test ..\Repro.sln --no-build --no-restore --configuration release --logger: trx -v minimal --filter Category!=SystemIntegration /p:CollectCoverage=true '/p:ExcludeByAttribute=\"GeneratedCodeAttribute\"' /p:Exclude=[*]*.Migrations.* '/p:ExcludeByFile=\"**/LoggerExtensions.FeaturePrefix.cs\"' /p:CoverletOutputFormat=opencover
    dotnet tool update -g dotnet-reportgenerator-globaltool
    reportgenerator "-reports:..\tests\**\*.opencover.xml" "-targetdir:coveragereport" -reporttypes:HTMLInline

    . .\coveragereport\index.htm
}
finally {
    Pop-Location
}
