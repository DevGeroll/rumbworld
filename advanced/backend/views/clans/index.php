<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\ClansSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Clans';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="clans-index">

    <h1><?= Html::encode($this->title) ?></h1>
    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <p>
        <?= Html::a('Create Clans', ['create'], ['class' => 'btn btn-success']) ?>
    </p>
    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'name',
            'description:ntext',
            'icon',
            'default_location_id',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>
</div>
