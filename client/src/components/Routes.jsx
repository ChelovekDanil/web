import { Route, Routes } from "react-router-dom"
import Login from "./noAuth/Login";
import Join from "./noAuth/Join";
import Image from "./Image";
import { PrivateRoute } from "./forAuth/PrivateRouter";

export const useRoutes = () => {
    return (
      <Routes>
        <Route path='/login' element={<Login/>} />
        <Route path='/join' element={<Join/>} />

        <Route element={<PrivateRoute />}>
          <Route path='/' element={<Image/>} />
          <Route path='/popularmovies' element={<Image/>} />
          <Route path='/films' element={<Image/>} />
          <Route path='/serials' element={<Image/>} />
        </Route>
      </Routes>
    )
}

export default useRoutes;   