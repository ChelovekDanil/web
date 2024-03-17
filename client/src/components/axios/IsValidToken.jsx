import axios from 'axios';

function IsValidToken() {
    const token = JSON.parse(localStorage.getItem("access_token"));

    return new Promise((resolve, reject) => {
        axios.get('https://localhost:7261/api/TokenValidator', {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        .then(() => {
            localStorage.setItem("isAuth", true)
            resolve(true)
        })
        .catch(() => {
            const username = JSON.parse(localStorage.getItem("user_name"));
            
            axios.get(`https://localhost:7261/api/RefreshToken?username=${username}`, {withCredentials: true})
            .then(response => {
                if (response.status === 200) {
                    console.log(response.data);
                    localStorage.setItem("access_token", JSON.stringify(response.data.accessToken))
                    localStorage.setItem("isAuth", true);
                    console.log("refresh token");
                    resolve(true);
                }
                else {
                    localStorage.setItem("isAuth", false);
                    resolve(false);
                }
            })
            .catch(error => {
                reject(error);
            })
        })  
    })
}

export default IsValidToken;