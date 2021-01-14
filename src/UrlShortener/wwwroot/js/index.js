function shorten() {
    const url = document.getElementById("input").value

    fetch(`/shorten`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(url)
    })
    .then(async (res) => {
        const json = await res.json()
        if (res.ok) {
            updateResult(json)
        }
        else {
            handleError(json)
        }
    })
}

function updateResult(result) {
    const elem = document.getElementById("result")
    const link = window.location.href + result.key
    elem.innerText = link
    elem.setAttribute("href", link)
}

function handleError(error) {
    const elem = document.getElementById("result")
    elem.innerText = error.error
    elem.removeAttribute("href")
}