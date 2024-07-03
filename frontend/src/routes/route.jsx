import React from "react";
import { Routes, Route} from 'react-router-dom';
import Home from "../components/Home";
import Create from "../components/Create";

const RouteComponent = () => {

    return (
        <div>
            <Routes>
                <Route
                    path="/"
                    element={<Home/>}
                />
                <Route
                    path="/create"
                    element={<Create/>}
                />
            </Routes>
            
        </div>
    )
}

export default RouteComponent;