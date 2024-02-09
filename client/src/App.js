import './App.css';
import Image from './components/Image';
import { Routes, Route } from 'react-router-dom';
import AuthPage from './components/noAuth/AuthPage';

function App() {
  return (
    <div className="App"> 
      <Routes>
        <Route path='/' element={<Image/>} />
        <Route path='/popularmovies' element={<Image/>} />
        <Route path='/films' element={<Image/>} />
        <Route path='/serials' element={<Image/>} />
        <Route path='/auth' element={<AuthPage/>} />
      </Routes>
    </div>
  );
}

export default App;
