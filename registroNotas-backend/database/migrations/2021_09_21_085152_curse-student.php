<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CurseStudent extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('curse_student', function (Blueprint $table) {
         
            $table->unsignedBigInteger('id_student');
            $table->unsignedBigInteger('id_curse');
            $table->float('grade');
            $table->timestamps();
            $table->foreign('id_student')->references('id')->on('students');
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
