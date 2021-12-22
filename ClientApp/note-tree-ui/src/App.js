import logo from './logo.svg';
import './App.css';
import { createDocument, getDocumentById, getLatestDocument, updateDocumentById } from './external-api-functions/fetch-documents';
import { getTreeByDocId, getNodeById, getAll, editNode } from './external-api-functions/fetch-docnodes';

function App() {
  const handleCreateDocument = () => {
    createDocument()
  }
  const handleGetDocumentById = () => {
    getDocumentById('2')
  }
  const handleLatestDocument = () => {
    getLatestDocument()
  }
  const handleUpdateDocumentById = () => {
    updateDocumentById({
      id: 10,
      title: "Old Document"
    })
  }

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
      <button onClick={handleCreateDocument}>
        createDocument
      </button>
      <button onClick={handleGetDocumentById}>
        getDocumentById
      </button>
      <button onClick={handleLatestDocument}>
        getLatestDocument
      </button>
      <button onClick={handleUpdateDocumentById}>
        updateDocumentById
      </button>
      <button onClick={() => getAll()}>
        getTree
      </button>
      <button onClick={() => getNodeById(3)}>
        getNodeById
      </button>
      <button onClick={() => getTreeByDocId(3)}>
        getTreeByDocId
      </button>
      <button onClick={() => editNode({id: 5, data: "test1"})}>
        editNode
      </button>
    </div>

  );
}

export default App;
