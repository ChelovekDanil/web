import { useEffect, useState } from "react";
import Header from "../components/Header";
import axios from "axios";
import '../components/style/SeparateMoviePage.css'
import IsValidToken from "../components/axios/IsValidToken";
import { useNavigate } from "react-router-dom";

function SeparateMoviePage() {
    const [movieData, setMovieData] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        IsValidToken()
        .then(success => {
            if (!success) {
                navigate("/login", {replace: true})
            }
        });

        const token = JSON.parse(localStorage.getItem("access_token"));
        const title = localStorage.getItem("name_movie");

        axios.get(`https://localhost:7261/api/popularMovies/${title}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        .then((response) => {
            setMovieData(response.data);
        });
    }, [navigate])

    return (
        <>
            <Header/>
            <div className="SeparateMoviePageComponent">
                <img src={movieData.url} alt="movieImage" id="separateMovieImage" />
                <div className="SeparateTextBlock">
                    <p id="separateTitle">Title: {movieData.title}</p>
                    <p id="separateCategory">Category: {movieData.category}</p>
                    <p id="separateDiscription">Discription: {movieData.discription}</p>
                </div>
            </div>
        </>
    )
}

export default SeparateMoviePage;