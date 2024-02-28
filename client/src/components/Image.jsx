import { useEffect, useState } from 'react';
import Header from './Header';
import axios from 'axios';
import './style/Image.css';
import { useLocation, useNavigate } from 'react-router-dom';

function Image() {
  const [photos, setPhotos] = useState([]);
  const [currentPage, setCurrentPage] = useState(0);
  const [fetching, setFetching] = useState(true);
  const location = useLocation();
  const navigate = useNavigate();

  useEffect(() => {
    const token = JSON.parse(localStorage.getItem("access_token"));

    if (fetching) {
      axios.get(`https://localhost:7261/api${GetPathname()}?count=${currentPage}`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
      })
      .then(response => {
          if (response.status === 200) {
            setPhotos([...photos, ...response.data]);
            setCurrentPage(prevState => prevState + 1);
          }
      })
      .catch(() => navigate("/login"))
      .finally(() => setFetching(false));
      }
  }, [fetching, currentPage, photos, location, navigate])

  // если url изменится
  useEffect(() => {
    const elements = document.querySelectorAll('.Cards');
    elements.forEach(element => element.remove());
    setCurrentPage(0);
    setFetching(true);
  }, [location])

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
      <Header/>
       <div className="Image">
        {photos.map(photo =>
            <div className='Cards' key={photo.id}>
                <img src={photo.url} alt='card' id='logoVideo'/>
                <p className='title'>{photo.title}</p>
                <p className='discription'>{photo.discription}</p>
            </div>
        )}
        </div>
    </>
  );
}

export default Image;