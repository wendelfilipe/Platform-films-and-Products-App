import React, { useState } from "react";
import api from "../api/Api";
import { useNavigate } from "react-router-dom";

const Create = () => {
    const [gender, setGender] = useState();
    const [name, setName] = useState();
    const [date, setDate] = useState();
    let [message, setMessage] = useState();
    let [stringImage, setStringImage] = useState();

    const navigate = useNavigate();

    const movie = {
        name: name,
        gender: parseInt(gender),
        date: date,
        image: stringImage ? stringImage.split("\\").pop() : ""
    }
    debugger

    async function createMovie(e){
        e.preventDefault();

        const response = await api.post("movie/CreateMovie", movie)
        message = response.data
        setMessage(message)

        alert(message)
        navigate("/")
        
    }

    return (
        <div className="form-create mt-4">
            <form>
                <div className="mb-3">
                    <label htmlFor="Name" className="form-label">Name</label>
                    <input type="text" className="form-control" id="name" value={name} onChange={(e) => setName(e.target.value)} aria-describedby="name" placeholder="the film name"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="gender" className="form-label">Gender</label>
                    <select className="form-select" aria-label="Default select example" value={gender} onChange={(e) => setGender(e.target.value)}>
                        <option selected>Select type</option>
                        <option value="1">Action</option>
                        <option value="2">Adventure</option>
                        <option value="3">Drama</option>
                        <option value="4">Romant Comedy</option>
                        <option value="5">Science Fiction</option>
                        <option value="6">Horror</option>
                    </select>
                </div>
                <div className="mb-3">
                    <label htmlFor="Date" className="form-label">Date</label>
                    <input type="date" className="form-control" id="date" value={date} onChange={(e) => setDate(e.target.value)}/>
                </div>
                <div className="mb-3">
                    <label for="formFile" className="form-label">Add Image</label>
                    <input className="form-control" type="file" id="formFile" value={stringImage} onChange={(e) => setStringImage(e.target.value)}/>
                </div>
               
                <button className="btn btn-primary me-2" onClick={createMovie}>Create</button>
                <button className="btn btn-primary" onClick={() => navigate("/")}>Back</button>
            </form>
        </div>
    )
}

export default Create;