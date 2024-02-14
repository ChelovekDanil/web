import { Route, Routes } from "react-router-dom";
import './App.css';
import Login from './components/noAuth/Login';
import Join from './components/noAuth/Join';
import Image from './components/Image';

function App() {
  return (
    <div className="App"> 
      <Routes>
        <Route path='/login' element={<Login/>} />
        <Route path='/join' element={<Join/>} />
        <Route path='/' element={<Image/>} />
        <Route path='/popularmovies' element={<Image/>} />
        <Route path='/films' element={<Image/>} />
        <Route path='/serials' element={<Image/>} />
      </Routes>
    </div>
  );
}

export default App;
