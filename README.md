# DB Script Generator

A console application and cmd-let (not tested yet) who generates sql script with/without data.

# What he does

Generates scripts from your SQL Server database.
You can choose between one script per object. Or just one file with all the scripts.
This little application was created so we can schedule the creation of database scripts in "development" in our company.
We schedule a daily script to be created in a network folder (with backup).

# How does it do?

It's very simple:

1) Download the application.
2) Install on a computer with the SQL Server client installed.
3) Edit the bd.json configuration file:
    
{
"Server": "SERVER_NAME",
"DataBaseName": "DATABASE_NAME"
"Username": "USER_NAME",
"Password": "PASSWORD",
"OneFilePerObject": true,
"Filename": "NAME_OF_FILE.sql",
"Items":
[
{ "Name": "TABLE_NAME1", "Type": 0, "ScriptData": true},
{ "Name": "TABLE_NAME2", "Type": 0, "ScriptData": false},
{ "Name": "PROCEDURE_NAME1", "Type": 1, "ScriptData": true}
]
}

4) Open the command prompt (cmd.exe)
5) Run the DbGenerator command db.json

*** ATTENTION ***

Beware the ways. You must add the path where the DbGenerator was installed in the PATH environment variable.

