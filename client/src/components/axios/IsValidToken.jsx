import axios from 'axios';

function IsValidToken() {
    const token = JSON.parse(localStorage.getItem("access_token"));

    axios.get('https://localhost:7261/api/TokenValidator', {
        headers: {
            Authorization: `Bearer ${token}`
        }
    })
    .then(response => {
        if (response.status === 200) {
            localStorage.setItem("isAuth", true)
        };
    })
    .catch(() => {
        const username = JSON.parse(localStorage.getItem("user_name"));
        console.log(username);
        axios.get(`https://localhost:7261/api/RefreshToken?username=${username}`, {withCredentials: true})
        .then(response => {
            if (response.status === 200) {
                console.log(response.data);
                localStorage.setItem("access_token", JSON.stringify(response.data.accessToken))
                localStorage.setItem("isAuth", true);
                console.log("refresh token");
            }
            else {
                localStorage.setItem("isAuth", false);
                console.log("401");
            }
        })
        .catch(() => {
            localStorage.setItem("isAuth", false);
        });
    })
}

export default IsValidToken;