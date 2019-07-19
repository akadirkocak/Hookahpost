export function PostData(type, userData) {
    let BaseURL = 'https://www.hookahpost.me/api/sampledata/';

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