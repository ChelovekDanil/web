import Header from "../components/Header";
import profileIcon from "../source/profileIcon.png";
import '../components/style/ProfilePage.css'
import { useEffect, useState } from "react";
import IsValidToken from "../components/axios/IsValidToken";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function ProfilePage() {
    const [userData, setUserData] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        IsValidToken();

        const username = JSON.parse(localStorage.getItem("user_name"));
        const token = JSON.parse(localStorage.getItem("access_token"));

        axios.get(`https://localhost:7261/api/User?Username=${username}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        .then((respones) => {
            setUserData(respones.data);
        });
    }, [])

    const Logout = () => {
        localStorage.setItem("isAuth", false);
        navigate("/login", {replace: true});
    }

    const DeleteAccount = () => {
        const token = JSON.parse(localStorage.getItem("access_token"));
        const username = JSON.parse(localStorage.getItem("user_name"));

        axios.delete(`https://localhost:7261/api/User?Username=${username}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })

        localStorage.setItem("isAuth", false);
        navigate("/join", {replace: true});
    }

    return (
        <>
            <Header/>
            <div className="profilePageBlock">
                <div className="profileBlock">
                    <img src={profileIcon} alt="profileIcon" id="profileIcon" />
                    <p id="profileUsername">Name: {userData.username}</p>
                    <p id="profileLogout" onClick={Logout}>Logout</p>
                    <p id="profileDelete" onClick={DeleteAccount}>Delete account</p>
                </div>
            </div>
        </>
    )
}

export default ProfilePage;