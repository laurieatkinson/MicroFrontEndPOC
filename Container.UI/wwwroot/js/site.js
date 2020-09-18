let microFrontEndDemo = {
    refreshEvent: new Event('refresh-data'),

    createRequestHeader: () => {
        // If all apps are under one domain, you can use this code to read from web storage
        const headers = new Headers();
        const token = window.localStorage.getItem('access_token');
        headers.append('Authorization', `Bearer ${token}`);
        return headers;
    },

    loadApp: (url, headers, insertDivId) => {
        window.fetch(url, { method: 'GET', mode: 'cors', headers: headers })
            .then((response) => {
                return response.text();
            })
            .then((html) => {
                let appContainer = document.getElementById(insertDivId);
                appContainer.innerHTML = html;
                // script will not execute unless the script is added into a script tag
                Array.from(appContainer.querySelectorAll("script")).forEach(scriptTag => {
                    const realScriptTag = document.createElement("script");
                    Array.from(scriptTag.attributes).forEach(attr => {
                        realScriptTag.setAttribute(attr.name, attr.value);
                    });
                    realScriptTag.appendChild(document.createTextNode(scriptTag.innerHTML));
                    scriptTag.parentNode.replaceChild(realScriptTag, scriptTag);
                });
            });
    }
};

(function startup() {
    let headers = microFrontEndDemo.createRequestHeader();
    window.fetch('config/config.json', { method: 'GET' })
        .then((response) => {
            return response.json();
        })
        .then((config) => {
            microFrontEndDemo.loadApp(config.app1Location, headers, 'app1Location');
            microFrontEndDemo.loadApp(config.app2Location, headers, 'app2Location');
            microFrontEndDemo.loadApp(config.app3Location, headers, 'app3Location');
            microFrontEndDemo.loadApp(config.app4Location, headers, 'app4Location');
        });
})();
