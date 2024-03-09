import { Navigate, Outlet, useLocation } from "react-router-dom";
import CheckAuth from "../scripts/CheckAuth.js";

export const PublicRoute = () => {
  const location = useLocation()

  return (
    CheckAuth() ? <Navigate to="/popularmovies" state={{ from: location }} replace /> : <Outlet/>
  )
};