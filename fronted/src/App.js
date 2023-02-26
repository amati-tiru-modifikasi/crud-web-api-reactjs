import "./App.css";
import Home from "./Home";
import Department from "./Department";
import Employee from "./Employee";
import { Routes, Route, Outlet, NavLink } from "react-router-dom";

function App() {
	return (
		<div className="App container">
			<h3 className="d-flex justify-content-center m-3">
				ReactJS with .NET Web API
			</h3>
      <nav className="navbar navbar-expand-sm bg-light navbar-dark">
				<ul className="navbar-nav">
					<li className="nav-item m-1">
						<NavLink
							className="btn btn-light btn-outline-primary"
							to="/"
						>
							Home
						</NavLink>
					</li>
					<li className="nav-item m-1">
						<NavLink
							className="btn btn-light btn-outline-primary"
							to="/department"
						>
							Department
						</NavLink>
					</li>
					<li className="nav-item m-1">
						<NavLink
							className="btn btn-light btn-outline-primary"
							to="/employee"
						>
							Employee
						</NavLink>
					</li>
				</ul>
			</nav>
      <Outlet />
			<Routes>
        <Route index element={<Home />} />
        <Route path="Department" element={<Department />} />
        <Route path="Employee" element={<Employee />} />
      </Routes>
		</div>
	);
}


export default App;