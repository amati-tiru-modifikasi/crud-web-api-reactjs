Pada Vidio tutorial youtube diatas bagian Fronted ReactJS, menggunakan **Class Component** dimana beberapa Depedensi lain seperti ReactJS dan React Router sudah menggunakan **Functional Component** , misalkan seperti dibawah ini

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