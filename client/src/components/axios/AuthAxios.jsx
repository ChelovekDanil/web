import axios from 'axios';  

function AuthAxios(Username, Password, url) {
    return new Promise((resolve, reject) => {
        axios.post(url, 
            {
                username: Username,
                password: Password
            },
            {withCredentials: true})
            .then(response => {
                if (response.status === 200 || response.status === 201) {
                    localStorage.setItem("access_token", JSON.stringify(response.data.accessToken));
                    localStorage.setItem("user_name", JSON.stringify(response.data.username));
                    localStorage.setItem("isAuth", true);
                    
                    resolve(true);
                }
                else {
                    resolve(false);
                }
            })
            .catch(error => {
                reject(error);
            });
    });
}

export default AuthAxios;