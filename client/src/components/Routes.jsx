import { Route, Routes } from "react-router-dom"
import Login from "./noAuth/Login";
import Join from "./noAuth/Join";
import { PrivateRoute } from "./forAuth/PrivateRouter";
import MoviePage from "../pages/MoviePage";
import { PublicRoute } from "./forAuth/PublicRouter";
import MainNoAuth from "../pages/MainNoAuth";
import AboutNoAuth from "../pages/AboutNoAuth";
import SeparateMoviePage from "../pages/SeparateMoviePage";
import ProfilePage from "../pages/ProfilePage";

export const useRoutes = () => {

    return (
      <Routes>
          <Route path='/login' element={<Login/>} />
          <Route path='/join' element={<Join/>} />

        <Route element={<PublicRoute/>}>
          <Route path="/main" element={<MainNoAuth/>}/>
          <Route path="/about" element={<AboutNoAuth/>}/>
        </Route>
        
        <Route element={<PrivateRoute />}>
          <Route path='/' element={<MoviePage/>} />
          <Route path='/popularmovies' element={<MoviePage/>} />
          <Route path='/films' element={<MoviePage/>} />
          <Route path='/serials' element={<MoviePage/>} />
          <Route path='/separatemovie' element={<SeparateMoviePage/>} />
          <Route path='/profile' element={<ProfilePage/>} />
        </Route>
      </Routes>
    )
}

export default useRoutes;   