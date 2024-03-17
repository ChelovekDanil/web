import '../components/style/ProfilePage.css'
import { Navigate, useLocation, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import Header from "../components/Header";
import IsValidToken from "../components/axios/IsValidToken";
import profileIcon from "../source/profileIcon.png";
import editButton from "../source/edit.png"
import axios from "axios";

function ProfilePage() {
    const [inputVisible, setInputVisible] = useState(false);
    const [userData, setUserData] = useState([]);
    const [newName, setNewName] = useState("");
    const location = useLocation();
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
            <Navigate to="/profile" state={{ from: location }} replace />
        });
    }, [location])

    const EditName = () => {
        IsValidToken();

        const token = JSON.parse(localStorage.getItem("access_token"));
        const Username = JSON.parse(localStorage.getItem("user_name"));
        
        axios.put("https://localhost:7261/api/User", {
            headers: {
                Authorization: `Bearer ${token}`
            },
            username: Username,
            newUsername: newName
        })
        .then(() => {
            localStorage.setItem("user_name", JSON.stringify(newName));
            navigate("/profile");
        });
    }

    const Logout = () => {
        localStorage.setItem("isAuth", false);
        navigate("/login", {replace: true});
    }

    const DeleteAccount = () => {
        IsValidToken()
        .then(success => {
            if (!success) {
                navigate("/login", {replace: true})
            }
        });

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

    const handlerImageClick = () => {
        inputVisible ? setInputVisible(false) : setInputVisible(true);
    }

    const ChangeNewName = (e) => {
        setNewName(e.target.value)
    }

    return (
        <>
            <Header/>
            <div className="profilePageBlock">
                <div className="profileBlock">
                    <img src={profileIcon} alt="profileIcon" id="profileIcon" />
                    <div className="nameBlock">
                        <div className="nameBlockText">
                            <p id="profileUsername">Name: {userData.username}</p>
                            <img src={editButton} alt="edit" id="editButton" onClick={handlerImageClick}/>
                        </div>
                        {inputVisible && (
                            <div className="nameBlockEdit">
                                <input type="text" placeholder="Enter new name" id="inputNewName"
                                    value={newName} onChange={ChangeNewName} />
                                <p id="editOldName" onClick={EditName}>Edit name</p>
                            </div>
                        )}
                    </div>
                    <p id="profileLogout" onClick={Logout}>Logout</p>
                    <p id="profileDelete" onClick={DeleteAccount}>Delete account</p>
                </div>
            </div>
        </>
    )
}

export default ProfilePage;