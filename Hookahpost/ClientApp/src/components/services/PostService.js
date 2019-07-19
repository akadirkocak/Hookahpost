export function PostData(type, userData) {
    let BaseURL = 'http://localhost:5000/api/sampledata/';

    return new Promise((resolve, reject) => {
        console.log(JSON.stringify(userData))
        fetch(BaseURL + type, {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              },
            method: 'POST',
            body: JSON.stringify(userData)
          })
          .catch((error) => {
            reject(error);
          });
      });
}