const URI = 'https://localhost:44308'

export const getAll = async () => {
    await fetch(URI + '/getAll').then(async (res) => {
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

export const getNodeById = async (id) => {
    await fetch(URI + '/getById/' + id).then(async (res) => {
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


export const getTreeByDocId = async (id) => {
    await fetch(URI + '/getByDocId/' + id).then(async (res) => {
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

export const editNode = async (data) => {
    await fetch(URI + '/editNode/' + data.id, {
        headers: { 'Content-Type': 'application/json', },
        method: "PUT",
        body: JSON.stringify(data)
    }).then( async (res) => {
        return {'status': res.status}
    }).catch((error) => {
        console.warn(error)
        return {'error': error.message}
    })
}

export const addNode = async (data) => {
    await fetch(URI + '/add/' + data.documentId, {
        headers: { 'Content-Type': 'application/json', },
        method: "POST",
        body: JSON.stringify(data)
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

export const deleteNode = async (id) => {
    await fetch(URI + '/api/DocNodes/' + id, {
        method: "DELETE"
    }).then( async (res) => {
        return {'status': res.status}
    }).catch((error) => {
        console.warn(error)
        return {'error': error.message}
    })
}