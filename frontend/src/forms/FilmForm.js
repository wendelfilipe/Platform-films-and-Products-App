import React, { useState } from "react";
import '../styles/Style.css'
import { useNavigate } from "react-router-dom";
import { Modal, Button, Form } from 'react-bootstrap';
import api from "../api/Api";

const Filmform = (props) => {
    const [showUpdate, setShowUpdate] = useState(false);
    const [showDelete, setShowDelete] = useState(false);
    const [showClassification, setShowClassification] = useState();
    let [name, setName] = useState();
    let [classification, setClassification] = useState();
    let [date, setDate] = useState();
    let [stringImage, setStringImage] = useState();
    let [gender, setGender] = useState();
    let [writeComment, setWriteComment] =useState();
    let id = props.idPassed;
    let comment = props.commentPassed;
    let image = props.imagePassed;

    if(name == null)
        name = props.namePassed;

    if(date == null)
        date = props.datePassed;
    
    if(classification == null)
        classification = props.classificationPassed;
    
    if(comment == null)
        comment = "Nenhum comentario ainda!"

    if(gender == null)
        gender = props.genderPassed;
    

    //To update a film
    const movie = {
        id: id,
        name: name,
        gender: gender,
        date: date,
        classification: classification,
        comment:writeComment,
        image: stringImage ? stringImage.split("\\").pop() : ""
    };

    const closeUpdateModal = () =>{
        setShowUpdate(false);
        setGender(null);
        window.location.reload();
    } 

    const showUpdateModal = () => setShowUpdate(true);


    async function updateMovie(){
        const response = await api.put("movie/UpdateMovie", movie);
        let message = response.data;
        alert(message);
        window.location.reload();
    }

    //To delete a film
    const closeDeleteModal = () =>{
        setShowDelete(false);
    }

    const showDeleteModal = () => setShowDelete(true);

    async function deleteMovie(){
        const response = await api.delete(`movie/DeleteMovie/${id}`);
        let message = response.data;
        alert(message);
        setShowDelete(false);
        window.location.reload();
    };

    //To Update Comment
    const movieWithComment = {
        id: id,
        name: name,
        gender: gender,
        date: date,
        classification: classification,
        comment:writeComment,
        image: image
    }

    async function updateComment(){
        await api.put("movie/UpdateMovie", movieWithComment)
        window.location.reload();
    }

    //To Classification film

    const closeClassificationModal = () => setShowClassification(false);
    
    const showClassificationModal = () => setShowClassification(true);


    const movieWithClassification = {
        classification: parseInt(classification),
        movieId: id
    }

    async function rateMovie(){
        const response = await api.post("user/CreateUser", movieWithClassification)
        let message = response.data
        alert(message)
        window.location.reload();
    }

    

    return (
        <div className="container-group d-flex flex-column">
            <div className="container">
                <div className="box-film">
                    <img className="box-film"src={`${process.env.PUBLIC_URL}/img/${image}`} alt={name}></img>
                </div>
                <div className="show-comment">
                        Comentarios: {comment} 
                </div>  
            </div>
            <div className="mt-2">
                <button className="btn btn-primary ms-4" onClick={showUpdateModal}>Update</button> 
                <button className="btn btn-primary ms-2" onClick={showDeleteModal}>Delete</button>
            </div>
            <div className="mt-2 ms-4">{name} - {date} <a onClick={showClassificationModal}>{
                    classification === 1 ? 
                        <div className="mb-2">
                            <i className="bi bi-star-fill"></i> 
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                        </div> : 
                    classification === 2 ?  
                        <div className="mb-2">
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                        </div> :
                    classification === 3 ?
                        <div className="mb-2">
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                        </div> :
                    classification === 4 ?
                        <div className="mb-2">
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star"></i>
                        </div> :
                    classification === 5 ?
                        <div className="mb-2">
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                            <i className="bi bi-star-fill"></i>
                        </div> : 
                        <div className="mb-2">
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                            <i className="bi bi-star"></i>
                        </div>
                }
               </a>
            </div>
            <div>
                <input className='comment' type="text" value={writeComment} onChange={(e) => setWriteComment(e.target.value)} placeholder="Comments"  />
                <button className="btn btn-primary ms-2" onClick={updateComment}>Comment</button>
            </div>
            <div className="App">
                <Modal show={showUpdate} onHide={closeUpdateModal}>
                    <Modal.Header closeButton>
                        <Modal.Title>Fill the Form</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                    <Form>
                        <Form controlId="name">
                           <label htmlFor="Name" className="form-label">Name</label>
                           <input type="text" className="form-control" value={name} onChange={(e) => setName(e.target.value)} aria-describedby="name" placeholder="The name of the film" />
                        </Form>
                        <Form controlId="gender">
                            <label htmlFor="Gender" className="form-label">Gender</label>
                            <select className="form-select" aria-label="Default select example" value={gender} onChange={(e) => setGender(e.target.value)}>
                                <option value="1">Action</option>
                                <option value="2">Adventure</option>
                                <option value="3">Drama</option>
                                <option value="4">Romant Comedy</option>
                                <option value="5">Science Fiction</option>
                                <option value="6">Horror</option>
                            </select>
                        </Form>
                        <Form controlId="date">
                            <label htmlFor="Date" className="form-label">Date</label>
                            <input type="text" className="form-control" value={date} onChange={(e) => setDate(e.target.value)} aria-describedby="Date" />
                        </Form>
                        <Form>
                            <label for="formFile" className="form-label">Add Image</label>
                            <input className="form-control" type="file" id="formFile" value={stringImage} onChange={(e) => setStringImage(e.target.value)}/>
                        </Form>
                    </Form>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={closeUpdateModal}>
                            Close
                        </Button>
                        <Button variant="primary" onClick={updateMovie}>
                            Edit
                        </Button>
                    </Modal.Footer>
                </Modal>
            </div>
            <div className="App">
                <Modal show={showDelete} onHide={closeDeleteModal}>
                    <Modal.Header closeButton>
                        <Modal.Title>Are you sure you want to dele this ? </Modal.Title>
                    </Modal.Header>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={closeDeleteModal}>
                            Close
                        </Button>
                        <Button variant="primary" onClick={deleteMovie}>
                            Delete
                        </Button>
                    </Modal.Footer>
                </Modal>
                <Modal show={showClassification} onHide={closeClassificationModal}>
                    <Modal.Header closeButton>
                        <Modal.Title>What is the rating for this filme from 1 to 5 ?</Modal.Title>
                    </Modal.Header>
                    <Modal.Footer>
                        <Modal.Body>

                            <select className="form-select" aria-label="Default select example" value={classification} onChange={(e) => setClassification(e.target.value)}>
                                <option selected>Select type</option>
                                <option value="1">1-Too bad</option>
                                <option value="2">2-Bad</option>
                                <option value="3">3-Regular</option>
                                <option value="4">4-Good</option>
                                <option value="5">5-Very good</option>
                            </select>
                        </Modal.Body>
                        <Button variant="secondary" onClick={closeClassificationModal}>
                            Close
                        </Button>
                        <Button variant="primary" onClick={rateMovie}>
                            Rate
                        </Button>
                    </Modal.Footer>
                </Modal>
            </div>            
        </div> 
    )

}
export default Filmform;