import React, { useState, ChangeEvent, FormEvent } from 'react';
import { Schedule } from './Schedule'
import axios from 'axios';
import TimePicker from 'react-time-picker'

export const CalenderList = () => {
    const defaultProps:Schedule[] = [];

    const [schedules, setPosts]: [Schedule[], (schedules: Schedule[]) => void] = React.useState(defaultProps);
    
    const [schedule, setSchedule]: [Schedule | null, (schedule: Schedule) => void] = React.useState<Schedule | null>(null);

    const [loading, setLoading]: [boolean, (loading: boolean) => void] = React.useState<boolean>(true);
    const [id, setId] = useState(0);
    const [names, setName] = useState("");
    const [years, setYear] = useState(0);
    const [months, setMonth] = useState(0);
    const [days, setDay] = useState(0);
    const [times, setTime] : [Date, (time: Date) => void] = useState<Date>(new Date());
    const [descriptions, setDescription] = useState("");

    const [edit, setEdit] = useState(false);

    const handleNameChange = (e: ChangeEvent<HTMLInputElement>) => { 
        setName(e.currentTarget.value);
    };

    const refreshPage = () => { 
      window.location.reload(); 
    }

    function editSchedule(value : Schedule) {
      setId(value.id);
      setName(value.name);
      setYear(value.year);
      setMonth(value.month);
      setDay(value.day);
      setTime(value.time);
      setDescription(value.description);
      setEdit(true);
      console.log(value);
    }

    function deleteSchedule (value : Schedule) {
      console.log(value);

      axios({
        method: 'post',
        url: 'https://calender-api-ammon.herokuapp.com/api/calender/delete',
        data: {
          Id: value.id,
          Name: value.name,
          Year: value.year,
          Month: value.month,
          Day: value.day,
          Time: value.time,
          Description: value.description
        }
      });
    }

    const handleYearChange = (e: ChangeEvent<HTMLInputElement>) => { 
        
        setYear(parseInt(e.currentTarget.value));
    };

    const handleMonthChange = (e: ChangeEvent<HTMLInputElement>) => { 
        setMonth(parseInt(e.currentTarget.value));
    };

    const handleDayChange = (e: ChangeEvent<HTMLInputElement>) => { 
        setDay(parseInt(e.currentTarget.value));
    };


    const handleDescriptionChange = (e: ChangeEvent<HTMLInputElement>) => { 
        setDescription(e.currentTarget.value);
    };

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        
        if(edit)
        {
          axios({
            method: 'post',
            url: 'https://calender-api-ammon.herokuapp.com/api/calender/update',
            data: {
              Id: id,
              Name: names,
              Year: years,
              Month: months,
              Day: days,
              Time: times,
              Description: descriptions
            }
          });
        } else 
        {
          axios({
            method: 'post',
            url: 'https://calender-api-ammon.herokuapp.com/api/calender/addcalender',
            data: {
              Id: id,
              Name: names,
              Year: years,
              Month: months,
              Day: days,
              Time: times,
              Description: descriptions
            }
          });
        }
        
        setId(0);
        setName("");
        setYear(0);
        setMonth(0);
        setDay(0);
        setTime(new Date());
        setDescription("");
        setEdit(false);
      };

    const [error, setError]: [string, (error: string) => void] = React.useState("");
    React.useEffect(() => {
        axios
        .get<Schedule[]>("https://calender-api-ammon.herokuapp.com/api/calender", {
        headers: {
            "Content-Type": "application/json"
        },
        }).then(response => {
            setPosts(response.data);
            setLoading(false);
          }).catch(ex => {
            const error =
            ex.response.status === 404
              ? "Resource not found"
              : "An unexpected error has occurred";
            setError(error);
            setLoading(false);
          });
    }, []);
    
    return (
        <div>
        <ul>
        <table>
            <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Month</th>
                            <th>Day</th>
                            <th>Year</th>
                            <th>Time</th>
                            <th>Description</th>
                        </tr>
            </thead>
            <tbody>
            {
                schedules.map((scheduleItem) =>(
                   <tr key={scheduleItem.id}>
                        <td>{scheduleItem.id}</td>
                        <td>{scheduleItem.name}</td>
                        <td>{scheduleItem.month}</td>
                        <td>{scheduleItem.day}</td>
                        <td>{scheduleItem.year}</td>
                        <td>{scheduleItem.time}</td>
                        <td>{scheduleItem.description}</td>
                        <td><button onClick={() => editSchedule(scheduleItem)}>Edit</button></td>
                        <td><button onClick={() => deleteSchedule(scheduleItem)}>Delete</button></td>
                   </tr>
                ))
            }
            </tbody>
       </table>
        </ul>
        {error && <p className="error">{error}</p>}

        <hr />
        <form  onSubmit={handleSubmit}>
            <h1>Create Schedule Form</h1>
            <label>
            Name:
            <input type="text" placeholder="Name..." onChange={handleNameChange} value={names} />
            </label>
            <hr />
            <label>
            Month:
            <input type="number" placeholder="Month..." onChange={handleMonthChange} value={months} />
            </label>
            <hr />
            <label>
            Day:
            <input type="number" placeholder="Day..." onChange={handleDayChange} value={days} />
            </label>
            <hr />
            <label>
            Year:
            <input type="number" placeholder="Year..." onChange={handleYearChange} value={years} />
            </label>
            <hr />
            <label>
            Description:
            <input type="text" placeholder="Description..." onChange={handleDescriptionChange} value={descriptions} />
            </label>
            <hr />
            <input type="submit" value="Submit" />
        </form>
        <button onClick={refreshPage} >Refresh</button>
      </div>
    );
};