## Bagian Backend (API)

Untuk Backend ada perbedaan, misalkan ada File **startup.cs** untuk melakukan Allow CORS config FILE, misalkan seperti berikut ini:

```c#
//Enable CORS
services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// script diatas terdapat di file Startup.cs
```

menjadi


```c#
builder.Services.AddCors(options =>
{
options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy  =>
                    {
                    policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials()
                            .WithOrigins("https://localhost:44454","https://persahabatan.co.id");
                    });
});

// script diatas ada di file Program.cs
```

selebihnya sama, hanya penyesuaian configurasi saja. :)

## Bagian Frontend (UI)

Pada Vidio tutorial youtube diatas menggunakan **Class Component** dimana beberapa Depedensi lain seperti ReactJS dan React Router sudah menggunakan **Functional Component** , misalkan seperti dibawah ini

```typescript
componentDidMount() {
    this.refreshList();
}
componentDidUpdate() {
    this.refreshList();
}
```

menjadi 

```typescript
useEffect(() => {
    const getDepartment = async () => {
    try {
        await fetch(`http://localhost:5253/api/department`)
        .then(res => res.json())
        .then(data => {
        return setDataDepartment(data)
    })
        } catch (e) {
            throw new Error(e);
        }
    }

    getDepartment();
},[]);
```

dan beberapa perbedaan di navigasi menu.