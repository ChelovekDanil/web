import { Navigate, Outlet, useLocation } from "react-router-dom";

export const PrivateRoute = () => {
  const location = useLocation()

  const checkAuth = () => {
    if (localStorage.getItem("access_token") === "true"){
      return true;
    }
    else {
      return false;
    }
  }

  return (
    checkAuth ? <Outlet/> : <Navigate to="/login" state={{ from: location }} replace />
  )
};