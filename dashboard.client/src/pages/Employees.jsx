import { useEffect, useState } from 'react';
import { DataManager } from '@syncfusion/ej2-data';
import { GridComponent, ColumnsDirective, ColumnDirective, Toolbar, Page, Search, Inject } from '@syncfusion/ej2-react-grids'
import { employeesGrid , fetchData} from '../data/dummy'
import { Header } from '../components'
import axios from 'axios';
const Employees = () => {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:5113/api/EmployeesData');

        if (!response.ok) {
          // Handle non-successful responses
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const responseData = await response.json();
        setData(responseData);
      } catch (error) {
        setError(error.message);
      }
    };

    fetchData();
  }, []); // The empty dependency array ensures that this effect runs only once, similar to componentDidMount

  // Render content based on the data or error state
  if (error) {
    return <div>Error: {error}</div>;
  }
  return (

    <div className='m-2 md:m-10 p-2 md:p-10 bg-white rounded-3xl'>
      <Header title="Employees" category="Page"/>
          <GridComponent
       dataSource={data}
      allowPaging
      allowSorting
      toolbar={['Search']}
      width="auto"
      
      >
        <ColumnsDirective>
          {employeesGrid.map((item,index) => (
            <ColumnDirective key={index} {...item}/>
          ))}
        </ColumnsDirective>
        <Inject services={[Page,Search, Toolbar]}/>
      </GridComponent>
    </div>
  )
}

export default Employees