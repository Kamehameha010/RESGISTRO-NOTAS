<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CurseProfesor extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {

            Schema::create('curse_profesor', function (Blueprint $table) {
             
                $table->unsignedBigInteger('id_profesor');
                $table->unsignedBigInteger('id_curse');
                $table->float('grade');
                $table->timestamps();
                $table->foreign('id_profesor')->references('id')->on('profesors');
                $table->foreign('id_curse')->references('id')->on('cursos');
            });
        
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        //
    }
}
