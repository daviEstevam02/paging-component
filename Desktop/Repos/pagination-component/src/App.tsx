import { useEffect, useState } from 'react'
import { Pagination } from './components/Pagination'
import { getAllClients } from './service/client.service';

function App() {
  const [count, setCount] = useState(0)
  const [ data, setData ] = useState([]);

  useEffect(() => {
    async function fetchData(){
      const { data } = await getAllClients(0, 5);

      setData(data.Data);
      setCount(data.Count)
    }

    fetchData()
  },[])

  return (
    <div>
        <Pagination 
          action={(skip: number, top: number) => {
            async function fetchData(){
              const { data } = await getAllClients(skip, top)
              setData(data.Data);
            }
            fetchData()
          }}
          count={count}
        />
    </div>
  )
}

export default App
