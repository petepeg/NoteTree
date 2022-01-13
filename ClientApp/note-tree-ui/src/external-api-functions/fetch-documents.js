const URI = 'https://localhost:44308'
const endpoint = '/api/Documents/'

export const createDocument = async () => {
    await fetch(URI + endpoint).then(async (res) => {
        if (res.ok) {
            const response = await res.json()
            console.log(response)
            return response
        } else {
            return {}
        }
    }).catch((error) => {
        console.warn(error)
        return {}
    })
}

export const getLatestDocument = async () => {
    await fetch(URI + endpoint,
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
        }).then(async (res) => {
            if (res.ok) {
                const response = await res.json()
                console.log(response)
                return response
            } else {
                return {}
            }
        }).catch((error) => {
            console.warn(error)
            return {}
        })
}

export const getDocumentById = async (id) => {
    await fetch(URI + endpoint + id).then(async (res) => {
        if (res.ok) {
            const response = await res.json()
            console.log(response)
            return response
        } else {
            return {}
        }
    }).catch((error) => {
        console.warn(error)
        return {}
    })
}


export const updateDocumentById = async (data) => {
    await fetch(URI + endpoint + data.id,
        {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(data)
        }).then(async (res) => {
            return { 'status': res.status }
        }).catch((error) => {
            console.warn(error)
            return { 'error': error.message }
        })
}

export const deleteDocumentById = async (id) => {
    await fetch(URI + endpoint + id).then(async (res) => {
        return { 'status': res.status }
    }).catch((error) => {
        console.warn(error)
        return { 'error': error.message }
    })
}

