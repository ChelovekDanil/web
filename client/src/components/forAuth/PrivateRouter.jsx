import { Navigate, Outlet, useLocation } from "react-router-dom";
import CheckAuth from "../scripts/CheckAuth.js";

export const PrivateRoute = () => {
  const location = useLocation()

  const checkAuth = () => {
    if (localStorage.getItem("isAuth") === "true"){
      return true;
    }
    else {
      return false;
    }
  }

  return (
    CheckAuth() ? <Outlet/> : <Navigate to="/login" state={{ from: location }} replace />
  )
};