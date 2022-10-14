##Auth

###Register

```
POST {{host}}/auth/register
```


###User
"id": "f48d48e4-ed1e-45c0-a2fc-7ab9306b92d1",
"firstName": "Jason",
"lastName": "Vu",
"email": "jasontest@gmail.com",
"password": "Jas0ntest!"

####Note: Secret key
```
dotnet user-secrets init --project .\BuberDinner.Api\
dotnet user-secrets set --project .\BuberDinner.Api\ "JwtSettings:Secret" "super-secret-key-from-user-secrets"
dotnet user-secrets list --project .\BuberDinner.Api\
```