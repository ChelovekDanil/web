import { useEffect, useState } from 'react';
import axios from 'axios';
import './style/Image.css';
import { useLocation, useNavigate } from 'react-router-dom';
import IsValidToken from './axios/IsValidToken';

function Image() {
  const [movies, setMovies] = useState([]);
  const [currentPage, setCurrentPage] = useState(0);
  const [fetching, setFetching] = useState(true);
  const location = useLocation();
  const navigate = useNavigate();

  let keyCard = 0;

  useEffect(() => {
    const token = JSON.parse(localStorage.getItem("access_token"));

    if (fetching) {
      IsValidToken()
        .then(success => {
            if (!success) {
                navigate("/login", {replace: true})
            }
        });

      axios.get(`https://localhost:7261/api${GetPathname()}?count=${currentPage}`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
      })
      .then(response => {
          if (response.status === 200) {
            setMovies([...movies, ...response.data]);
            setCurrentPage(prevState => prevState + 1);
          }
      })
      .catch(() => {
        if (localStorage.getItem("isAuth") === "false") {
          navigate("/login", {replace: true})
        }
        else {
          navigate(`${GetPathname()}`)
        }
      })
      .finally(() => setFetching(false));
      }
  }, [fetching, currentPage, movies, location, navigate])

  // если url изменится
  useEffect(() => {
    const elements = document.querySelectorAll('.Cards');
    elements.forEach(element => element.remove());
    
    setCurrentPage(0);
    
    setFetching(true);
  }, [location])

  // при скролле
  useEffect(() => {
    document.addEventListener('scroll', scrollHandler);
    return function() {
      document.removeEventListener('scroll', scrollHandler);
    }
  }, [])

  const scrollHandler = () => {
    if (document.documentElement.scrollHeight - (document.documentElement.scrollTop + window.innerHeight) < 500) {
      setFetching(true);
    }
  }

  const GetPathname = () => {
    return window.location.pathname === "/" || window.location.pathname === "" ? "/popularmovies" : window.location.pathname
  }

  return (
    <>
      <div className="Image">
        {movies.map(movie =>
          <div className='Cards' key={keyCard++}>
              <img src={movie.url} alt='movie' id='logoVideo' onClick={() => {
                  localStorage.setItem("name_movie", movie.title);
                  navigate("/separatemovie");
                }}/>
              <p className='title'>{movie.title}</p>
              <p className='discription'>{movie.discription}</p>
          </div>
        )}
      </div>
    </>
  );
}

export default Image;