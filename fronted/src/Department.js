import React, { Component } from 'react'

export default class Department extends Component {

  constructor(props){
    super(props);
    this.state = {
      departments:[]
    }
  }

  refreshList(){
    fetch(`http://localhost:5253/api/department`)
    .then(res => res.json())
    .then(data => {
      this.setState({ departments:data })
    })
  }

  componentDidMount() {
    this.refreshList();
  }
  componentDidUpdate() {
    this.refreshList();
  }

  render() {
    const {
      departments
    }=this.state;
    
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
            {departments.map(dep => {
              <tr key={dep.DepartmentId}>
                <td>{dep.DepartmentId}</td>
                <td>{dep.DepartmentName}</td>
                <td>
                  <button>Edit</button>
                  <button>Delete</button>
                </td>
              </tr>
            })}
          </tbody>
        </table>
      </div>
    )
  }
}
