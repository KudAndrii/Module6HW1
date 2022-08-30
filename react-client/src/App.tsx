import React from "react";
import logo from "./logo.svg";
import "./App.css";
import GetProductComponent from "./Components/GetProductComponent";
import InsertProductComponent from "./Components/InsertProductComponent";
import DeleteProductComponent from "./Components/DeleteProductComponent";
import UpdateProductComponent from "./Components/UpdateProductComponent";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <div>
                    <img src={logo} className="App-logo" alt="logo" />
                </div>
                <div>
                    Edit <code>src/App.tsx</code> and save to reload.
                </div>
            </header>
            <ul className="list">
                <GetProductComponent />
                <InsertProductComponent />
                <UpdateProductComponent />
                <DeleteProductComponent />
            </ul>
        </div>
    );
}

export default App;
