import React, { useState, useEffect } from 'react'

export default function Department() {

  const [dataDepartment, setDataDepartment] = useState([]);

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

  return ( 
    <div>
    <table className='table table-striped'>
      <thead>
        <tr>
          <th>Department ID</th>
          <th>Department Name</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        {dataDepartment.map((dep) => {
          return(
            <tr key={dep.DepartmentId}>
              <td>{dep.DepartmentId}</td>
              <td>{dep.DepartmentName}</td>
              <td>
                <button>Edit</button>
                <button>Delete</button>
              </td>
            </tr>
          )
        })}
      </tbody>
    </table>
  </div>
  )
}
