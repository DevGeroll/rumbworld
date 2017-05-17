<?php

namespace backend\assets;

use yii\web\AssetBundle;

/**
 * Main backend application asset bundle.
 */
class AppAsset extends AssetBundle
{
    public $basePath = '@webroot';
    public $baseUrl = '@web';
    public $css = [
        'css/site.css',
		'css/sb-admin-2.min.css',
		'morrisjs/morris.css',
		'font-awesome/css/font-awesome.min.css'
    ];
    public $js = [
		'metisMenu/metisMenu.min.js',
		'js/sb-admin-2.min.js',
    ];
    public $depends = [
        'yii\web\YiiAsset',
        'yii\bootstrap\BootstrapAsset',
    ];
}
