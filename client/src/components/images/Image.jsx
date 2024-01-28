import { useEffect, useState } from 'react';
import Header from '../header/Header';
import axios from 'axios';
import './Image.css';
import { useLocation } from 'react-router-dom';

function Image() {
  const [photos, setPhotos] = useState([]);
  const [currentPage, setCurrentPage] = useState(0);
  const [fetching, setFetching] = useState(true);
  const location = useLocation();

  useEffect(() => {
    if (fetching) {
      axios.get(`https://localhost:7110${window.location.pathname}?count=${currentPage}`)
        .then(response => {
          // add new element to array
          setPhotos([...photos, ...response.data]);
          setCurrentPage(prevState => prevState + 1);
        })
        .finally(() => setFetching(false));
    }
  }, [fetching, currentPage, photos, location])

  // если url изменится
  useEffect(() => {
    console.log("ku");
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
                <p className='discription'>{photo.discription}</p>
            </div>
        )}
        </div>
    </>
  );
}

export default Image;