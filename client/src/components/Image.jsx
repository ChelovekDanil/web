import { useEffect, useState } from 'react';
import Header from './Header';
import axios from 'axios';
import './style/Image.css';
import { json, useLocation } from 'react-router-dom';

function Image() {
  const [photos, setPhotos] = useState([]);
  const [currentPage, setCurrentPage] = useState(0);
  const [fetching, setFetching] = useState(true);
  const location = useLocation();

  useEffect(() => {
    const token = JSON.parse(localStorage.getItem("accessToken"));
    console.log(token);
    if (fetching) {
      axios.get(`https://localhost:7261/api${window.location.pathname}?count=${currentPage}`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
    })
    .then(response => {
        // добавить новые элементы в массив
        setPhotos([...photos, ...response.data]);
        setCurrentPage(prevState => prevState + 1);
    })
    .finally(() => setFetching(false));
    }
  }, [fetching, currentPage, photos, location])

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

  return (
    <>
      <Header/>
       <div className="Image">
        {photos.map(photo =>
            <div className='Cards' key={photo.id}>
                <img src={photo.url} alt='card' id='logoVideo'/>
                <p className='title'>{photo.title}</p>
                <p className='discription'>{photo.discriptions}</p>
            </div>
        )}
        </div>
    </>
  );
}

export default Image;