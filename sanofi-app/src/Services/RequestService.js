class RequestService {
    constructor() {
        this.baseUrl = 'http://localhost:4000/api/requests'
    }

    getRequests() {
        return fetch(this.baseUrl)
        .then(function(response) { return response.json(); });
    }

    getRequest(id) {
        return fetch(`${this.baseUrl}/${id}`)
        .then(function(response) { return response.json(); });
    }

    draft(request) {
        return this.postData(`${this.baseUrl}/draft`, request);
    }    
    
    requestApproval(id) {
        return this.postData(`${this.baseUrl}/requestApproval`, {id});
    }     
    
    approve(id) {
        return this.postData(`${this.baseUrl}/approve`, {id});
    } 

    reject(id) {
        return this.postData(`${this.baseUrl}/reject`, {id});
    } 

    postData(url = ``, data = {}) {
          return fetch(url, {
              method: "POST",
              mode: "cors",
              cache: "no-cache",
              credentials: "same-origin",
              headers: {
                  "Content-Type": "application/json; charset=utf-8",
              },
              redirect: "follow",
              referrer: "no-referrer",
              body: JSON.stringify(data),
          })
          .then(response => response.json())
          .catch(error => alert(error));
    }
}

export default RequestService;