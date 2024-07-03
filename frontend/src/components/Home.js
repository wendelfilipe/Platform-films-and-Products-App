import React, { useEffect, useState } from 'react'
import '../styles/Style.css'
import Filmform from '../forms/FilmForm';
import api from '../api/Api';

const Home = () =>{
    //For Pagination
    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 2;

    //For all movies
    let [movies, setMovies] = useState([]);

    //By gender
    let [moviesByGender, setMoviesByGender] = useState();
    let [gender, setGender] = useState();

    //By name
    let [moviesByName, setMoviesByName] = useState();
    
    //For search a film by name
    let [searchFilm, setSearchFilm] = useState();

    //For pagination by name
    let currentItemsByName = null;
    let totalPageByName;

    if(moviesByName != null && moviesByName !== undefined){
        totalPageByName = Math.ceil(moviesByName.length / itemsPerPage )
    }

    if(moviesByName != null && moviesByName !== undefined){
        currentItemsByName = moviesByName.slice(
            (currentPage - 1) * itemsPerPage,
            currentPage * itemsPerPage
        )
    }

     //For pagination by gender
     let currentItemsByGender = null;
     let totalPageByGender;
 
     if(moviesByGender != null && moviesByGender !== undefined){
         totalPageByGender = Math.ceil(moviesByGender.length / itemsPerPage )
     }
 
     if(moviesByGender != null && moviesByGender !== undefined){
         currentItemsByGender = moviesByGender.slice(
             (currentPage - 1) * itemsPerPage,
             currentPage * itemsPerPage
         )
     }

    //For pagination by gender
    let currentItemsAllMovies;
    let totalPageAllMovies;

    if(movies != null && movies !== undefined){
        totalPageAllMovies = Math.ceil(movies.length / itemsPerPage )
    }

    if(movies != null && movies !== undefined){
        currentItemsAllMovies = movies.slice(
            (currentPage - 1) * itemsPerPage,
            currentPage * itemsPerPage
        )
    }

    //For change page
    const handlePageChange = (pageNumber) => {
        setCurrentPage(pageNumber);
      };

    //get all movies
    async function getMovies(){
        const response = await api.get("movie/GetAllMovies");
        movies = response.data
       
        if(typeof movies === "string")
        {
            alert(movies)
            movies = null
        }

        setMovies(movies)
    }

    if(gender === "0")
        window.location.reload();

    //get all movies by gender
    async function getMovieByGender(e){
        if(gender !== undefined && gender !== null && gender !== "0"){
            const response = await api.get(`movie/GetMoviesByGender/${gender}`)
            moviesByGender = response.data
            if(moviesByGender.length === 0)
                moviesByGender = null

            setMoviesByGender(moviesByGender)
        }
    }

    //get all movies by name
    useEffect(() => {
        if(searchFilm !== null && searchFilm !== undefined && searchFilm.trim() !== ""){
            getMoviesByName();
            
        }
    },[searchFilm]);

    async function getMoviesByName(){
        const response = await api.get(`movie/GetMovieByName/${searchFilm}`)
        moviesByName = response.data
        let sortMoviesByName = moviesByName.sort((a,b) => a.name.localeCompare(b.name))
        if(sortMoviesByName.length === 0)
            sortMoviesByName = null

        setMoviesByName(sortMoviesByName)
    }
    useEffect (() => {
        getMovies();
    }, []);

    if(currentItemsByGender != null && gender !== "0"){
        //For return a view by Gender
        return (
            <div>
                <h3 className='title'> Films Online </h3>
                <div className='container-head'>
                    <div className='conteiner-center'>
                        <a className='btn btn-primary me-2' href='/create'>Create new Film</a>
                        <input className='size-input' type='text' placeholder='search film' value={searchFilm} onChange={(e) => setSearchFilm(e.target.value)}/>
                        <select className='size-select' value={gender} onChange={(e) => setGender(e.target.value)}>
                            <option value="0">Select Type Gender</option>
                            <option value="1">Action</option>
                            <option value="2">Adventure</option>
                            <option value="3">Drama</option>
                            <option value="4">Romantic Comendy</option>
                            <option value="5">Science Fiction</option>
                            <option value="6">Horror</option>
                        </select>
                        <button className='btn btn-primary ms-2' onClick={getMovieByGender}>search</button>
                    </div>
                </div>
                <div className='mt-5 film-form'>
                    {currentItemsByGender.map(ms => (
                        <div key={ms.id} className='mt-4'>
                            <Filmform
                                namePassed={ms.name}
                                classificationPassed={ms.classification}
                                idPassed={ms.id}
                                datePassed={ms.date}
                                genderPassed={ms.gender}
                                commentPassed={ms.comment}
                                imagePassed={ms.image}
                            />
                        </div>
                    ))}
                </div>
                <div className='container-page'>
                    <button className='button-page'
                    onClick={() => handlePageChange(currentPage - 1)}
                    disabled={currentPage === 1}
                    >
                    Anterior
                    </button>
                    {[...Array(totalPageByGender)].map((_, index) => (
                    <button className='button-page'
                        key={index}
                        onClick={() => handlePageChange(index + 1)}
                        disabled={index + 1 === currentPage}
                    >
                        {index + 1}
                    </button>
                    ))}
                    <button className='button-page'
                    onClick={() => handlePageChange(currentPage + 1)}
                    disabled={currentPage === totalPageByGender}
                    >
                    Próximo
                    </button>
                </div>     
            </div>
        )
    }

    if(currentItemsByName != null){
        //For return a view by name
        return (
            <div>
                <h3 className='title'> Films Online </h3>
                <div className='container-head'>
                    <div className='conteiner-center'>
                        <a className='btn btn-primary mee-2' href='/create'>Create new Film</a>
                    <input className='size-input' type='text' placeholder='search film' value={searchFilm} onChange={(e) => setSearchFilm(e.target.value)}/>
                    <select className='size-select' value={gender} onChange={(e) => setGender(e.target.value)}>
                        <option value="0">Select Type Gender</option>
                        <option value="1">Action</option>
                        <option value="2">Adventure</option>
                        <option value="3">Drama</option>
                        <option value="4">Romantic Comendy</option>
                        <option value="5">Science Fiction</option>
                        <option value="6">Horror</option>
                    </select>
                    <button className='btn btn-primary ms-2' onClick={getMovieByGender}>search</button>
                    </div>
                </div>
                <div className='mt-5 film-form'>
                    {currentItemsByName.map(ms => (
                        <div key={ms.id} className='mt-4'>
                            <Filmform
                                namePassed={ms.name}
                                classificationPassed={ms.classification}
                                idPassed={ms.id}
                                datePassed={ms.date}
                                genderPassed={ms.gender}
                                commentPassed={ms.comment}
                                imagePassed={ms.image}
                            />
                        </div>
                    ))}   
                </div>
                <div className='container-page'>
                    <button className='button-page'
                    onClick={() => handlePageChange(currentPage - 1)}
                    disabled={currentPage === 1}
                    >
                    Anterior
                    </button>
                    {[...Array(totalPageByName)].map((_, index) => (
                    <button className='button-page'
                        key={index}
                        onClick={() => handlePageChange(index + 1)}
                        disabled={index + 1 === currentPage}
                    >
                        {index + 1}
                    </button>
                    ))}
                    <button className='button-page'
                    onClick={() => handlePageChange(currentPage + 1)}
                    disabled={currentPage === totalPageByName}
                    >
                    Próximo
                    </button>
                </div>           
            </div>
        )
    }
    //When there are no movies 
    if(movies != null && movies !== undefined && movies.length !== 0)
        {
            return (
                //For return a view of all movies
                <div>
                <h3 className='title'> Films Online </h3>
                <div className='container-head'>
                    <div className='conteiner-center'>
                        <a className='btn btn-primary me-2' href='/create'>Create new Film</a>
                        <input className='size-input' type='text' placeholder='search film' value={searchFilm} onChange={(e) => setSearchFilm(e.target.value)}/>
                        <select className='size-select' value={gender} onChange={(e) => setGender(e.target.value)}>
                            <option value="0">Select Type Gender</option>
                            <option value="1">Action</option>
                            <option value="2">Adventure</option>
                            <option value="3">Drama</option>
                            <option value="4">Romantic Comendy</option>
                            <option value="5">Science Fiction</option>
                            <option value="6">Horror</option>
                        </select>
                        <button className='btn btn-primary ms-2' onClick={getMovieByGender}>search</button>
                    </div>
                </div>
                <div className='mt-5 film-form'>
                    {currentItemsAllMovies.map(ms => (
                        <div key={ms.id} className='mt-4'>
                            <Filmform
                                namePassed={ms.name}
                                classificationPassed={ms.classification}
                                idPassed={ms.id}
                                datePassed={ms.date}
                                genderPassed={ms.gender}
                                commentPassed={ms.comment}
                                imagePassed={ms.image}
                            />
                        </div>
                    ))}  
                </div>
                <div className='container-page'>
                        <button className='button-page'
                        onClick={() => handlePageChange(currentPage - 1)}
                        disabled={currentPage === 1}
                        >
                        Anterior
                        </button>
                        {[...Array(totalPageAllMovies)].map((_, index) => (
                        <button className='button-page'
                            key={index}
                            onClick={() => handlePageChange(index + 1)}
                            disabled={index + 1 === currentPage}
                            >
                            {index + 1}
                        </button>
                        ))}
                        <button className='button-page'
                        onClick={() => handlePageChange(currentPage + 1)}
                        disabled={currentPage === totalPageAllMovies}
                        >
                        Próximo
                        </button>
                    </div>           
            </div>
        )    
    }
    return(
        <div>
            <h3 className='title'> Films Online </h3>
            <div className='container-head'>
                <div className='conteiner-center'>
                    <a className='btn btn-primary me-2' href='/create'>Create new Film</a>
                    <input className='size-input' type='text' placeholder='search film' value={searchFilm} onChange={(e) => setSearchFilm(e.target.value)}/>
                    <select className='size-select' value={gender} onChange={(e) => setGender(e.target.value)}>
                        <option value="0">Select Type Gender</option>
                        <option value="1">Action</option>
                        <option value="2">Adventure</option>
                        <option value="3">Drama</option>
                        <option value="4">Romantic Comendy</option>
                        <option value="5">Science Fiction</option>
                        <option value="6">Horror</option>
                    </select>
                    <button className='btn btn-primary ms-2' onClick={getMovieByGender}>search</button>
                </div>
            </div>
            <div className='container-page'>
                <h3 className='no-movies'>No movies registered, create a movie.</h3>
            </div>
        </div>
    )
}

export default Home;
