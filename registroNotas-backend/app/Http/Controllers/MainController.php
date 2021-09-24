<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Profesor;
use App\Models\Student;
use App\Models\User;
use Illuminate\Support\Facades\Hash;

class MainController extends Controller
{
    function login(){
        return view("auth.login");
    }
    function register(){
        return view("auth.register");
    }

    function save(Request $request){
        //validate inputs
        $request->validate(
            [
                'name'=>'required',
                'id_number'=>'required|unique:users',
                'password'=>'required|min:5'
            ]
        );

        //inserting to database
         $data=$request->input();
        $user =new User;
        $user->name=$data['name'];
        $user->id_number=$data['id_number'];
        $user->password=Hash::make($data['password']); 
        $user->rol_id=1;
        $save=$user->save();
        if($save){
            return back()->with("success","New user registered");
        }
        else{
            return back()->with("fail","Something went wrong, try again later");
        }
    }

    function check(Request $request){
               //validate inputs
               $request->validate(
                [  
                    'id_number'=>'required',
                    'password'=>'required|min:5'
                ]);

                $userInfo= User::where('id_number','=',$request->id_number)->first();
                if($userInfo){
                  if(Hash::check($request->password, $userInfo->password )){
                    $request->session()->put('LoggedUser',$userInfo->id);
                    return redirect('admin/dashboard');
                  }
                  else{
                    return back()->with("fail","incorrect Password ");
                }
                }
                else{
                    return back()->with("fail","User dont exist");
                }


    }
 
    
}
